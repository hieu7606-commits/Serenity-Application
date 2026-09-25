import { DeleteRequest, DeleteResponse, ListRequest, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { MovieCastRow } from "./MovieCastRow";

export namespace MovieCastService {
    export const baseUrl = 'MovieDB/MovieCast';

    export declare function Create(request: SaveRequest<MovieCastRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<MovieCastRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<MovieCastRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<MovieCastRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<MovieCastRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<MovieCastRow>>;

    export const Methods = {
        Create: "MovieDB/MovieCast/Create",
        Update: "MovieDB/MovieCast/Update",
        Delete: "MovieDB/MovieCast/Delete",
        Retrieve: "MovieDB/MovieCast/Retrieve",
        List: "MovieDB/MovieCast/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>MovieCastService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}