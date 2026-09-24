import { EntityDialog } from '@serenity-is/corelib';
import { GenreForm, GenreRow, GenreService } from '../../ServerTypes/MovieDB';
import { nsMovieDB } from '../../ServerTypes/Namespaces';

/**
 * The add/edit window for one genre.
 *
 * The registered name, Serene.MovieDB.GenreDialog, matters beyond this folder: the movie form's
 * Genre dropdown has in-place add, and it finds this dialog by taking its lookup key
 * ("MovieDB.Genre") and appending "Dialog". Rename the class and that button stops working unless
 * DialogType is set on the LookupEditor attribute in MovieRow.cs.
 */
export class GenreDialog extends EntityDialog<GenreRow, any> {
    static override [Symbol.typeInfo] = this.registerClass(nsMovieDB);

    protected override getFormKey() { return GenreForm.formKey; }
    protected override getRowDefinition() { return GenreRow; }
    protected override getService() { return GenreService.baseUrl; }

    protected form = new GenreForm(this);
}
