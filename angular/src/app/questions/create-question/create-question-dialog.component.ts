import { Component, Injector,  EventEmitter,Output } from '@angular/core';
import { QuestionServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';

@Component({
  selector: 'app-create-question-dialog',
  templateUrl: './create-question-dialog.component.html',  
})
export class CreateQuestionDialogComponent extends AppComponentBase{

  question: any = {
    title: '',
    text: ''
  };

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector:Injector,
    public questionService: QuestionServiceProxy, 
    public bsModalRef: BsModalRef) 
  {
    super(injector);
  }

  

  save(): void {
    this.questionService.createQuestion(this.question)
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
        
      });
  }

  cancel(): void {
    this.bsModalRef.hide();
  }
}
