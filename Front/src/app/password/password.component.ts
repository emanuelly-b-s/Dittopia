import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
@Component({
  selector: 'app-password',
  templateUrl: './password.component.html',
  styleUrls: ['./password.component.css'],
})
export class PasswordComponent {
  // Inputs podem ser acessados de fora do componente como propriedades HTML
  // Outputs podem ser acessados de fora do componente como eventos no estilo onclick
  @Output() valueChanged = new EventEmitter<string>();
  @Input() breakLineOnInput = true;
  @Input() canSeePassword = true;
  @Input() seePassword = false;
  @Output() seePasswordChanged = new EventEmitter<boolean>();

  protected inputType = 'text';
  protected inputStyle = 'color: black;';
  protected inputText = '';
  protected initialState = true;
  hide = true;

  password = new FormControl('', [
    Validators.required,
    Validators.minLength(8),
    Validators.pattern(
      '(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-zd$@$!%*?&].{8,}'
    ),
  ]);

  

  // Implmentamos OnInit para executar algum comportamento quando o componente inicializa
}
