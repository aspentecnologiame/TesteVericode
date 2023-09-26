import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, of, switchMap, throwError } from 'rxjs';
import { environment } from '../../../enviroments/environment';
import { BaseRequestModel } from '../../core/models/request/base.request.model'
import { BaseResponseModel } from '../../core/models/response/base.response.model';
import { TaskModel } from './models/task.model';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  private readonly URLS = {
    baseTask: "task"
  };

  constructor(private _httpClient: HttpClient) { }

  save(loginModel: TaskModel): Observable<BaseResponseModel<TaskModel>>
  {
      return this._httpClient.post(`${environment.urlApi}${this.URLS.baseTask}`, this.baseRequest<TaskModel>(loginModel)).pipe(
          switchMap((response: BaseResponseModel<TaskModel>) => {
              // Return a new observable with the response
              return of(response);
          })
      );
  }

  private baseRequest<T>(parameters: T): BaseRequestModel<T> {
    const base = new BaseRequestModel<T>();
    base.data = parameters;
    return base;
  }
}
