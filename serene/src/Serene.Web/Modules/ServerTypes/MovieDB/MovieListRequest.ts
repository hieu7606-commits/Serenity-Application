import { ListRequest } from "@serenity-is/corelib";

export interface MovieListRequest extends ListRequest {
    Genres?: number[];
}