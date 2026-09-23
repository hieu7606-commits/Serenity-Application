import { EntityGrid, QuickSearchField, localText } from '@serenity-is/corelib';
import { MovieColumns, MovieRow, MovieService } from '../../ServerTypes/MovieDB';
import { MovieDialog } from './MovieDialog';

/**
 * The Movie list: the table, its toolbar, paging, sorting, the search box and the Excel button.
 *
 * Almost none of that is written here. EntityGrid already knows how to be a grid; the four methods
 * below only tell it which columns to draw, which dialog to open, which row type it holds and which
 * service to call. Behaviour goes here as overrides - getButtons to add a toolbar button,
 * onClick for row clicks, getDefaultSortBy for the initial order.
 *
 * The imports come from ServerTypes, which sergen regenerates from the C# on every build. That is
 * what keeps the two sides in step: rename a column in MovieColumns.cs and this stops compiling
 * rather than quietly showing an empty column.
 */
export class MovieGrid extends EntityGrid<MovieRow> {
    // Registers the class under Serene.MovieDB.MovieGrid so the server can name it when rendering
    // the page. The trailing dot means "this namespace, plus the class name".
    static override [Symbol.typeInfo] = this.registerClass("Serene.MovieDB.");

    // Matches [ColumnsScript("MovieDB.Movie")] on MovieColumns.cs - the columns are fetched by key
    // at runtime, not hard-coded here.
    protected override getColumnsKey() { return MovieColumns.columnsKey; }
    // Opened when a row's edit link is clicked, and by the New Movie button.
    protected override getDialogType() { return MovieDialog; }
    // Field metadata: captions, types, and which property is the id.
    protected override getRowDefinition() { return MovieRow; }
    // Services/MovieDB/Movie, generated from the [Route] on MovieEndpoint.
    protected override getService() { return MovieService.baseUrl; }

    // Adds a dropdown to the search box for picking a single field; "All" (empty name) searches
    // every [QuickSearch] field. Names come from MovieRow.Fields so a typo fails to compile, and
    // titles from the Db.MovieDB.Movie.* local texts so they follow translations.
    protected override getQuickSearchFields(): QuickSearchField[] {
        const txt = (s: string) => localText(`Db.${MovieRow.localTextPrefix}.${s}`);
        const fld = MovieRow.Fields;
        return [
            { name: "", title: "All" },
            { name: fld.Description, title: txt(fld.Description) },
            { name: fld.Storyline, title: txt(fld.Storyline) },
            { name: fld.Year, title: txt(fld.Year) }
        ];
    }
}