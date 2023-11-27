import { Injectable } from '@angular/core';
import { HttpClient, HttpEventType } from '@angular/common/http';
import { catchError, last, map, Observable, of, ReplaySubject, switchMap, tap, throwError } from 'rxjs';
import { environment } from '../../../enviroments/environment';
import { BaseRequestModel } from '../../core/models/request/base.request.model'
import { BaseResponseModel } from '../../core/models/response/base.response.model';
import { TaskModel } from './models/task.model';
import * as signalR from "@microsoft/signalr"

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  private data: BaseResponseModel<TaskModel[]>;
  private _navigation: ReplaySubject<any> = new ReplaySubject<any>(1);

  private readonly URLS = {
    baseTask: "task"
  };

  constructor(private _httpClient: HttpClient) { }

  private hubConnection: signalR.HubConnection
  public startHubTaskConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
                            .withUrl(`${environment.hubUrl}${this.URLS.baseTask}`)
                            .build();
    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err))
  }

  public addTransferTaskDataListener = () => {
    this.hubConnection.on('transfertaskdata', (data) => {
      this.data = data;
      console.log(data);
    });
  }

  save(loginModel: TaskModel): Observable<BaseResponseModel<TaskModel>>
  {
      return this._httpClient.post(`${environment.urlApi}${this.URLS.baseTask}`, this.baseRequest<TaskModel>(loginModel)).pipe(
          switchMap((response: BaseResponseModel<TaskModel>) => {
              // Return a new observable with the response
              return of(response);
          })
      );
  }

  getAll(): Observable<BaseResponseModel<TaskModel[]>>
    {
        return this._httpClient.get<BaseResponseModel<TaskModel[]>>(`${environment.urlApi}${this.URLS.baseTask}`).pipe(
            tap((navigation) => {
                this._navigation.next(navigation);
            })
        );
    }

  private baseRequest<T>(parameters: T): BaseRequestModel<T> {
    const base = new BaseRequestModel<T>();
    base.data = parameters;
    return base;
  }

  private mapProcessList<T>(event: any): Array<T> {
    if (event.type === HttpEventType.Response) {
      return Object.assign([], event.body);
    }

    return undefined;
  }

  private mapProcess<T>(event: any): T {
    if (event.type === HttpEventType.Response) {
      return event.body as T;
    }
    return undefined;
  }
}
