import { DeleteRequest, DeleteResponse, ListResponse, RetrieveRequest, RetrieveResponse, SaveRequest, SaveResponse, ServiceOptions, serviceRequest } from "@serenity-is/corelib";
import { MovieListRequest } from "./MovieListRequest";
import { MovieRow } from "./MovieRow";

export namespace MovieService {
    export const baseUrl = 'MovieDB/Movie';

    export declare function Create(request: SaveRequest<MovieRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<MovieRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<MovieRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<MovieRow>>;
    export declare function List(request: MovieListRequest, onSuccess?: (response: ListResponse<MovieRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<MovieRow>>;

    export const Methods = {
        Create: "MovieDB/Movie/Create",
        Update: "MovieDB/Movie/Update",
        Delete: "MovieDB/Movie/Delete",
        Retrieve: "MovieDB/Movie/Retrieve",
        List: "MovieDB/Movie/List"
    } as const;

    [
        'Create',
        'Update',
        'Delete',
        'Retrieve',
        'List'
    ].forEach(x => {
        (<any>MovieService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}