import {makeAutoObservable, runInAction} from "mobx";
import * as userApi from "../../api/users";
import {IUser} from "../../interfaces/users";

class UserStore {
    user: IUser | null = null;
    isLoading = false;

    constructor() {
        makeAutoObservable(this);
    }

    fetchUser = async (id: string) => {
        try {
            this.isLoading = true;
            const res = await userApi.getById(id);
            runInAction(() => {
                this.user = res.data;
                this.isLoading = false;
            });
        } catch (e) {
            if (e instanceof Error) {
                console.error(e.message);
            }
            this.isLoading = false;
        }
    };
}

export default UserStore;