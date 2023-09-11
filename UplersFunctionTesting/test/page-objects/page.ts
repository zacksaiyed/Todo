export default class Page {
  constructor() {}

  async navigateTo(path: string) {
    await browser.url(path);
    await browser.maximizeWindow();
  }

  async clickElement(ele: WebdriverIO.Element) {
    await ele.waitForDisplayed({ timeout: 5000 });
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

  async getvalueForElement(ele: WebdriverIO.Element) {
    await ele.waitForDisplayed({ timeout: 5000 });
    if (ele) {
      return await ele.getText();
    }
  }
  async elementExists(ele: WebdriverIO.Element) {
    var isExists =await ele.isDisplayed();
    return isExists;
   
  }
  
  
  
}
