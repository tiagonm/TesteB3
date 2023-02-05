import { Component, OnInit } from '@angular/core';
import { AlertService } from 'src/app/services/alert.service';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'home-page',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss']
})

export class HomePage implements OnInit {
  constructor(
    private apiService: ApiService,
    private alertService: AlertService
  ) { }

  public data: any = { initialValue: '', months: '' };
  public cdb: any = {};

  public ngOnInit() {

  }

  public async sendItem() {
    if (!this.data.initialValue || !this.data.months) {
      this.alertService.show('Atenção!', 'Preencha todos os campos para prosseguir.');
      return;
    }

    if (isNaN(this.data.initialValue) || this._parseNumber(this.data.initialValue) < 1) {
      this.alertService.show('Atenção!', 'O valor precisa ser maior que um.');
      return;
    }

    if (isNaN(this.data.months) || this._parseNumber(this.data.months) < 1) {
      this.alertService.show('Atenção!', 'A quantidade precisa ser maior que um.');
      return;
    }

    await this._postItem();
  }

  private async _postItem() {
    try {
      const obj = { initialValue: parseInt(this.data.initialValue), months: parseInt(this.data.months) };
      this.cdb = await this.apiService.postItem(obj);     
    } catch (error: any) {      
      const msg = error && error.error && error.error.message ? error.error.message : 'Ocorreu um erro. Tente novamente';
      this.alertService.show('Atenção!', msg);
    }
  }

  private _parseNumber(value: any) {
    try {
      value = parseInt(value);
    } catch (error) {
      console.warn('ERRO _parseNumber');
    }

    return value;
  }

}
