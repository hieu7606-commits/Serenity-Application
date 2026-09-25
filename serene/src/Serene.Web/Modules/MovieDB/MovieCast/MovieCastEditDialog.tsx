import { GridEditorDialog } from "@serenity-is/extensions";
import { MovieCastForm, MovieCastRow } from "../../ServerTypes/MovieDB";
import { nsMovieDB } from "../../ServerTypes/Namespaces";
import "./MovieCastEditDialog.css";

/**
 * Adds or edits one cast entry inside the movie dialog. GridEditorDialog never calls a service:
 * Save hands the entity back to MovieCastEditor, and nothing reaches the database until the movie
 * itself is saved.
 */
export class MovieCastEditDialog extends GridEditorDialog<MovieCastRow> {
    static override [Symbol.typeInfo] = this.registerClass(nsMovieDB);

    protected override getFormKey() { return MovieCastForm.formKey; }
    protected override getRowDefinition() { return MovieCastRow; }

    protected form = new MovieCastForm(this);
}
