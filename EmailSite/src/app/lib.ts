import { Email } from "./email"
let BASE_URL: string = 'https://localhost:7031/api/Email'



export function apiCall(method: string, payload: Email , api?: string) {
    const options: RequestInit = {
        method: method,
        headers: {
            'Content-Type': 'application/json'
        },
    }
    if( method === 'POST') {
        options.body = JSON.stringify(payload)
    }
    if(api){
        return fetch(`${BASE_URL}/${api}`, options)
    }else{
        return fetch(`${BASE_URL}`, options)
    }
}

