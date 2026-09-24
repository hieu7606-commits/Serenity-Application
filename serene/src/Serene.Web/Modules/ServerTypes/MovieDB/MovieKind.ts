import { registerEnum } from "@serenity-is/corelib";

export enum MovieKind {
    Film = 1,
    TvSeries = 2,
    MiniSeries = 3
}
registerEnum(MovieKind, 'Serene.MovieDB.MovieKind', 'MovieDB.MovieKind');