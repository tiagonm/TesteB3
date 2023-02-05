import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.prod';
import { HttpService } from './http.service';

@Injectable({
	providedIn: 'root'
})

export class ApiService {
	constructor(
		private httpService: HttpService) { }

	public setItem(): Promise<any> {
		return this.httpService.get(environment.apiUrl + '/api/Cdb/calculation', {});
	}

	public postItem(data: any): Promise<any> {
		return this.httpService.post(environment.apiUrl + '/api/Cdb/calculation', data);
	}
}
