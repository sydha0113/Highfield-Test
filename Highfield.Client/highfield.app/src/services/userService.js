const API_URL = "users/userdata";


const UserService = {
    getUsers: async () => {
        try{
            const response = await fetch(API_URL);
            if(!response.ok){
                throw new Error(`HTTP error. Status: ${response.status}`);
            }
            else{
                var result = await response.json();
                return result;
            }
        }
        catch(error){
            console.error(`Error when trying to retrieve users from: ${API_URL}. Errors: ${error}`);
            throw error;
        }
    }
}

export default UserService;