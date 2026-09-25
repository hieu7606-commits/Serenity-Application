import { toId } from "@serenity-is/corelib";
import { GridEditorBase } from "@serenity-is/extensions";
import { MovieCastColumns, MovieCastRow, PersonRow } from "../../ServerTypes/MovieDB";
import { nsMovieDB } from "../../ServerTypes/Namespaces";
import { MovieCastEditDialog } from "./MovieCastEditDialog";

/**
 * The cast grid inside the movie dialog - the editor for MovieForm.CastList. Edits happen in
 * memory: this grid holds the list, the value goes to the server with the movie, and
 * MasterDetailRelation on MovieRow.CastList writes the MovieCast rows.
 *
 * Registered with registerEditor so sergen generates the [MovieCastEditor] attribute that
 * MovieForm.cs uses.
 */
export class MovieCastEditor<P = {}> extends GridEditorBase<MovieCastRow, P> {
    static override [Symbol.typeInfo] = this.registerEditor(nsMovieDB);

    protected override getColumnsKey() { return MovieCastColumns.columnsKey; }
    protected override getDialogType() { return MovieCastEditDialog; }
    protected override getRowDefinition() { return MovieCastRow; }

    protected override getAddButtonCaption() {
        return "Add";
    }

    // The dialog only returns PersonId and Character, but the grid shows PersonFullName. Nothing
    // on the server fills it in during in-memory editing, so look the name up here, before the row
    // is added, or the Actor/Actress column stays blank.
    protected override async validateEntity(row: MovieCastRow, id: any) {
        if (!await super.validateEntity(row, id))
            return false;

        row.PersonId = toId(row.PersonId);
        const lookup = await PersonRow.getLookupAsync();
        row.PersonFullName = lookup.itemById[row.PersonId]?.FullName;
        return true;
    }
}
