import { Injectable } from '@angular/core';
import { HttpClient, HttpEventType, HttpRequest } from '@angular/common/http';
import { environment } from '../../../../enviroments/environment';
import { BaseRequestModel } from '../../../core/models/request/base.request.model';
import { BaseResponseModel } from 'app/core/models/response/base.response.model';
import { LoginModel } from './models/login.model';
import { catchError, Observable, of, switchMap, throwError } from 'rxjs';
import { last, map } from 'rxjs/operators';
import { UserService } from 'app/core/user/user.service';
import { User } from 'app/core/user/user.types';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private _authenticated: boolean = false;

  private readonly URLS = {
    baseLogin: "login"
  };

  constructor(protected httpClient: HttpClient, private _userService: UserService) { }

  set accessToken(token: string)
  {
      localStorage.setItem('accessToken', token);
  }

  get accessToken(): string
  {
      return localStorage.getItem('accessToken') ?? '';
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

  

  public login(loginModel: LoginModel): Observable<any> {
    const req = new HttpRequest('POST', `${environment.urlApi}${this.URLS.baseLogin}`, this.baseRequest<LoginModel>(loginModel));
    return this.httpClient.request(req).pipe(
      catchError(() =>

          // Return false
          of(false)
      ),
      switchMap((response: any) => {

          // Store the access token in the local storage
          this.accessToken = response.token;

          // Set the authenticated flag to true
          this._authenticated = true;

          // Store the user on the user service
          this._userService.user = {
              id    : 'cfaad35d-07a3-4447-a6c3-d8c3d54fd5df',
              name  : 'Admin',
              email : 'admin@saudemaxs.com.br',
              avatar: 'assets/images/avatars/brian-hughes.jpg',
              status: 'online'
          };

          // Return true
          return of(response.body);
      })
    );
  }

  private baseRequest<T>(parameters: T): BaseRequestModel<T> {
    const base = new BaseRequestModel<T>();
    base.data = parameters;
    return base;
  }

}
