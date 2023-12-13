import { QuestionsAnswersTemplatePage } from './app.po';

describe('QuestionsAnswers App', function() {
  let page: QuestionsAnswersTemplatePage;

  beforeEach(() => {
    page = new QuestionsAnswersTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
