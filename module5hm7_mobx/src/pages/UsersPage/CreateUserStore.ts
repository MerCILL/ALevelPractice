import {makeAutoObservable} from "mobx";
import * as userApi from "../../api/users";
import {INewUser} from "../../interfaces/users";

class CreateUserStore {
    name = '';
    job = '';
    error = { name: false, job: false };

    constructor() {
        makeAutoObservable(this);
    }

    setName = (name: string) => {
        this.name = name;
        this.error.name = false;
    };

    setJob = (job: string) => {
        this.job = job;
        this.error.job = false;
    };

    createUser = async () => {
        if (!this.name || !this.job) {
            this.error = { name: !this.name, job: !this.job };
            return;
        }
        const user: INewUser = {
            name: this.name,
            job: this.job,
        };
        try {
            await userApi.create(user);
            console.log('User created');
            this.name = ''; 
            this.job = ''; 
        } catch (error) {
            console.error(error);
        }
    };
}

export default CreateUserStore;