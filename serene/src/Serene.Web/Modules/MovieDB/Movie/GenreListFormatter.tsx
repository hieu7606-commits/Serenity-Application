import { Formatter, Lookup, formatterTypeInfo, registerType } from "@serenity-is/corelib";
import { FormatterContext } from "@serenity-is/sleekgrid";
import { GenreRow } from "../../ServerTypes/MovieDB/GenreRow";
import { nsMovieDB } from "../../ServerTypes/Namespaces";

// Shared by every cell: the first cell to render starts one lookup load, the rest wait on it.
let lookup: Lookup<GenreRow>;
let promise: Promise<Lookup<GenreRow>>;

/**
 * Renders the Genres column - a list of genre ids - as their names, "Drama, Sci-fi".
 *
 * The Genre lookup is loaded asynchronously so the grid never blocks on it: cells show a spinner
 * until it arrives, then the grid is redrawn with names. Registered under nsMovieDB so sergen
 * generates the [GenreListFormatter] attribute MovieColumns.cs puts on the column.
 */
export class GenreListFormatter implements Formatter {
    static [Symbol.typeInfo] = formatterTypeInfo(nsMovieDB); static { registerType(this); }

    format(ctx: FormatterContext) {

        let idList = ctx.value as number[];
        if (!idList || !idList.length)
            return "";

        let byId = lookup?.itemById;
        if (byId) {
            return idList.map(id => {
                var genre = byId[id];
                // escape: genre names are user-entered, so never write them into the cell as HTML.
                return ctx.escape(genre == null ? id : genre.Name);
            }).join(", ");
        }

        // The lookup is only held for the one redraw it triggers, then dropped, so a genre added
        // or renamed since is picked up the next time the grid renders.
        promise ??= GenreRow.getLookupAsync().then(l => {
            lookup = l;
            try {
                ctx.grid?.invalidate();
            }
            finally {
                lookup = null;
                promise = null;
            }
        }).catch(() => promise = null);

        return <i class="fa fa-spinner"></i>;
    }
}
