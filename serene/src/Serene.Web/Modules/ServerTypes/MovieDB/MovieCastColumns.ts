import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { MovieCastRow } from "./MovieCastRow";

export interface MovieCastColumns {
    PersonFullName: Column<MovieCastRow>;
    Character: Column<MovieCastRow>;
}

export class MovieCastColumns extends ColumnsBase<MovieCastRow> {
    static readonly columnsKey = 'MovieDB.MovieCast';
    static readonly Fields = fieldsProxy<MovieCastColumns>();
}