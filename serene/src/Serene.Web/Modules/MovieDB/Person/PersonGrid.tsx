import { EntityGrid } from '@serenity-is/corelib';
import { PersonColumns, PersonRow, PersonService } from '../../ServerTypes/MovieDB';
import { nsMovieDB } from '../../ServerTypes/Namespaces';
import { PersonDialog } from './PersonDialog';

/**
 * The Person list. Wired the same way as MovieGrid: columns, dialog, row type and service.
 */
export class PersonGrid extends EntityGrid<PersonRow> {
    static override [Symbol.typeInfo] = this.registerClass(nsMovieDB);

    protected override getColumnsKey() { return PersonColumns.columnsKey; }
    protected override getDialogType() { return PersonDialog; }
    protected override getRowDefinition() { return PersonRow; }
    protected override getService() { return PersonService.baseUrl; }
}
