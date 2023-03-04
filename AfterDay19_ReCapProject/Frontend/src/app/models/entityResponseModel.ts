import { ResponseModel } from "./responseModel";

export interface EntityResponseModel<T> extends ResponseModel {
    data : T;
}