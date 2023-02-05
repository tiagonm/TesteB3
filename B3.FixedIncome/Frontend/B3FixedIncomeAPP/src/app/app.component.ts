import { Component, OnInit } from '@angular/core';
import { AlertService } from './services/alert.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})


export class AppComponent implements OnInit {
  public titulo?: any;
  public subtitulo?: any;

  constructor(
    private alertService: AlertService
  ) { }

  public ngOnInit() {
    this.alertService.titulo.subscribe((val: string) => {
      this.titulo = val;
    });

    this.alertService.subtitulo.subscribe((val: string) => {
      this.subtitulo = val;
    });
  }

  public closeAlert() {
    this.titulo = null;
    this.subtitulo = null;
  }

}
