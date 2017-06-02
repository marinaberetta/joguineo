import { Component } from '@angular/core';
import { AlertController } from 'ionic-angular';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  constructor(public alertCtrl: AlertController) {
  }

  showPrompt() {
    let prompt = this.alertCtrl.create({
      title: 'Excluir pontuação',
      subTitle: ' ',
      message: "Digite a senha para excluir a pontuação:",
      inputs: [
        {
          name: 'pass',
          id: 'excluirPass',
          placeholder: 'Senha'
        }
      ],
      buttons: [
        {
          text: 'Cancel',
          handler: data => {
          }
        },
        {
          text: 'Excluir',
          cssClass: 'excluirBtn',
          handler: data => {
          }
        }
      ]
    });
    prompt.present();
  }

}
