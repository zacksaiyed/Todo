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
  return  await this.filterList(await this.todoListValue,inputValue);
}



}
export { TodoPage };

