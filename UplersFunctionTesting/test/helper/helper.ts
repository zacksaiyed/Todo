class Helper{
    generateRandomString(length: number): string {
        const allowedCharacters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
        let randomString = '';
      
        for (let i = 0; i < length; i++) {
          const randomIndex = Math.floor(Math.random() * allowedCharacters.length);
          randomString += allowedCharacters.charAt(randomIndex);
        }
      
        return randomString;
      }
}
export { Helper };