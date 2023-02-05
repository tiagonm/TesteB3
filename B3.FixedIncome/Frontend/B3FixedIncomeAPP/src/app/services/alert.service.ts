import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class AlertService {
  public titulo: BehaviorSubject<string> = new BehaviorSubject<string>('');
  public subtitulo: BehaviorSubject<string> = new BehaviorSubject<string>('');

  public show(titulo?: string, subtitulo?: string) {
    this.titulo.next(titulo || '');
    this.subtitulo.next(subtitulo || '');
  }
}
