import { DocKeeperTemplatePage } from './app.po';

describe('DocKeeper App', function() {
  let page: DocKeeperTemplatePage;

  beforeEach(() => {
    page = new DocKeeperTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
