import Page from "./page.js";


//@ts-ignore
class TodoPage extends Page{

constructor() {
    super();
}
get todoList(){return $$('//table[@id="todoList"]')}
get todoInput(){return $('//input[@id="todoInput"]')}
get todoButton(){return $('//button[@id="todoButton"]')}
get todoListValue() {return $$(`//table[@id="todoList"]//tbody//tr`)}

async checkIfTodoList(){
    var ele=(await this.todoList)[0].waitForDisplayed({timeout:10000})
    
    if(await ele){
       var arrayLength= await this.todoList.length;

      return arrayLength>0;
    }
    return false
}
async addNewTask(inputValue:string){
    await this.setvalueForElement(await this.todoInput,inputValue);
    await this.clickElement(await this.todoButton);
    await browser.pause(5000);
  return  await this.filterList(inputValue);
}
async editTask(inputValue:string, index:number){
  
  await this.clickElement(await $(`//table[@id="todoList"]//tbody//tr[${index}]//td[3]//a[@title="Edit"]`));
  await browser.pause(3000);
  await this.setvalueForElement(await $(`//table[@id="todoList"]//tbody//tr[${index}]//td[2]//input`),inputValue);
  await browser.pause(6000);
  await this.clickElement(await $(`//table[@id="todoList"]//tbody//tr[${index}]//td[3]//a[@title="Save"]`));
  await browser.pause(3000);
  return await this.filterList(inputValue);

}

async deleteTask(index:number){
  
  let inputValue = await this.getvalueForElement(await $(`//table[@id="todoList"]//tbody//tr[${index}]//td[2]//span`))
  await this.clickElement(await $(`//table[@id="todoList"]//tbody//tr[${index}]//td[3]//a[@title="Remove"]`));
  await browser.pause(3000);
  return await this.filterList(inputValue);

}

async markTaskCompleted(index:number){
  

  await this.clickElement(await $(`//table[@id="todoList"]//tbody//tr[${index}]//td[3]//a[@title="Complete"]`));
  await browser.pause(3000);
  return await this.elementExists(await $(`//table[@id="todoList"]//tbody//tr[${index}]//td[2]//span[@class="text-decoration-line-through ng-star-inserted"]`))

}



async filterList(textValue: string|undefined) {
    
  if(textValue===undefined) return {recordExits : false , recordValue:textValue};

  let rowCount =await $$(`//table[@id="todoList"]//tbody//tr`).length;

  for (let i = 0; i < await rowCount; i++) {

    var cellValue = await $(`//table[@id="todoList"]//tbody//tr[${i+1}]//td[2]`).getText();
    if (cellValue === textValue) {
      return {recordExits : true , recordValue:textValue};
    }
  }
  return  {recordExits : false , recordValue:textValue};
}




}
export { TodoPage };

