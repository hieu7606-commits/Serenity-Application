import { EntityDialog } from '@serenity-is/corelib';
import { PersonForm, PersonRow, PersonService } from '../../ServerTypes/MovieDB';
import { nsMovieDB } from '../../ServerTypes/Namespaces';

/**
 * The add/edit window for one person. Its title shows FullName because that is the row's name
 * property - carried over from PersonRow.cs by the generated PersonRow.ts, which is why a change
 * to NameProperty needs a rebuild and transform before the dialog notices.
 */
export class PersonDialog extends EntityDialog<PersonRow, any> {
    static override [Symbol.typeInfo] = this.registerClass(nsMovieDB);

    protected override getFormKey() { return PersonForm.formKey; }
    protected override getRowDefinition() { return PersonRow; }
    protected override getService() { return PersonService.baseUrl; }

    protected form = new PersonForm(this);
}
