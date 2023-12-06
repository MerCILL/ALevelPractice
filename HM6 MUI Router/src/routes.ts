import {FC} from "react";
import Home from "./pages/Home/Home";
import Route from "./interfaces/route";
import User from "./pages/UsersPage/User";
import Resource from "./pages/Resources/Resource";
import ResourcePage from "./pages/ResourcesPage/Resource";
import CreateUser from "./pages/UsersPage/CreateUser";


export const routes: Array<Route> = [
    {
        key: 'home-route',
        title: 'Users',
        path: '/',
        enabled: true,
        component: Home
    },

    {
        key: 'user-route',
        title: 'User',
        path: '/user/:id',
        enabled: false,
        component: User
    },

    {
        key: 'users-route',
        title: 'User',
        path: '/users',
        enabled: false,
        component: Home
    },

    {
        key: 'resources-route',
        title: 'Resources',
        path: '/resources',
        enabled: true,
        component: Resource
    },

    {
        key: 'resource-route',
        title: 'Resource',
        path: '/resource/:id',
        enabled: false,
        component: ResourcePage
    },

    {
        key: 'create-user-route',
        title: 'Create User',
        path: '/create-user',
        enabled: false,
        component: CreateUser
    },
]