import { EntityDialog } from '@serenity-is/corelib';
import { MovieForm, MovieRow, MovieService } from '../../ServerTypes/MovieDB';
import "./MovieDialog.css";

/**
 * The add/edit window for one movie, with its Save, Delete and Close buttons.
 *
 * EntityDialog does the work: it retrieves the record when opened on an existing row, builds the
 * inputs, validates them and calls the service. The methods below only say which form layout to
 * build, which row type is being edited and where to send it. Behaviour goes here as overrides -
 * afterLoadEntity to adjust the loaded record, getSaveEntity to shape what is sent, onSaveSuccess
 * to react once it is stored.
 */
export class MovieDialog extends EntityDialog<MovieRow, any> {
    static override [Symbol.typeInfo] = this.registerClass("Serene.MovieDB.");

    // Matches [FormScript("MovieDB.Movie")] on MovieForm.cs - the layout is fetched by key, so
    // reordering the C# properties reorders the dialog with no change here.
    protected override getFormKey() { return MovieForm.formKey; }
    protected override getRowDefinition() { return MovieRow; }
    protected override getService() { return MovieService.baseUrl; }

    // Typed access to the editors: this.form.Title.value rather than looking inputs up by name, so
    // a renamed field is a compile error instead of a runtime surprise. Wiring two fields together
    // - say, filling Year from ReleaseDate - starts here.
    protected form = new MovieForm(this);
}