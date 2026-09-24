import { EntityGrid } from '@serenity-is/corelib';
import { GenreColumns, GenreRow, GenreService } from '../../ServerTypes/MovieDB';
import { nsMovieDB } from '../../ServerTypes/Namespaces';
import { GenreDialog } from './GenreDialog';

/**
 * The Genres list. Wired the same way as MovieGrid: columns, dialog, row type and service.
 */
export class GenreGrid extends EntityGrid<GenreRow> {
    static override [Symbol.typeInfo] = this.registerClass(nsMovieDB);

    protected override getColumnsKey() { return GenreColumns.columnsKey; }
    protected override getDialogType() { return GenreDialog; }
    protected override getRowDefinition() { return GenreRow; }
    protected override getService() { return GenreService.baseUrl; }
}
