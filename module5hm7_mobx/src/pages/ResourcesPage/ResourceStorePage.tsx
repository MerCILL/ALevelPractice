import {makeAutoObservable, runInAction} from "mobx";
import * as resourceApi from "../../api/resources";
import { IResource } from "../../interfaces/resources";

class ResourceStorePage {
    resource: IResource | null = null;
    isLoading = false;

    constructor() {
        makeAutoObservable(this);
    }

    fetchResource = async (id: string) => {
        try {
            this.isLoading = true;
            const res = await resourceApi.getById(id);
            runInAction(() => {
                this.resource = res.data;
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

export default ResourceStorePage;