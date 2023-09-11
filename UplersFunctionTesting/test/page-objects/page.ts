export default class Page {
  constructor() {}

  async navigateTo(path: string) {
    await browser.url(path);
    await browser.maximizeWindow();
  }

  async clickElement(ele: WebdriverIO.Element) {
    await ele.waitForClickable({ timeout: 5000 });
    if (ele) {
      await ele.click();
    }
  }

  async setvalueForElement(ele: WebdriverIO.Element, text: string) {
    await ele.waitForDisplayed({ timeout: 5000 });
    if (ele) {
      await ele.setValue(text);
    }
  }
  async filterList(ele: WebdriverIO.Element[], textValue: string) {
    for (let i = 0; i < await ele.length; i++) {
      var cellValue = await ele[i + 1].getText();
      if (cellValue === textValue) {
        return true;
      }
    }
    return false;
  }
}
