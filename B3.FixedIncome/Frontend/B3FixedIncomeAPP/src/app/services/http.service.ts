import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

export interface HttpServiceParam {
  name: string;
  value: string;
}

@Injectable()
export class HttpService {

  constructor(private httpClient: HttpClient) { }

  public post(url: any, data: any) {
    return this.httpClient.post(url, data)
      .toPromise()
      .then(response => {
        let json = JSON.stringify(response);
        json = JSON.parse(json);
        return json;
      })
      .catch(erro => {
        let json = JSON.stringify(erro);
        json = JSON.parse(json);
        throw erro;
      });
  }

  public get(url: any, data: any) {
    return this.httpClient.get(url, { params: data })
      .toPromise()
      .then(response => {
        let json = JSON.stringify(response);
        json = JSON.parse(json);
        return json;
      })
      .catch(erro => {
        let json = JSON.stringify(erro);
        json = JSON.parse(json);
        throw erro;
      });
  }

}
