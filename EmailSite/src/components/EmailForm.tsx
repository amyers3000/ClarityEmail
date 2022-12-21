import React, { useEffect, useState } from 'react'
import { Email } from '../app/email'
import { apiCall } from '../app/lib'

interface IError {
    display: boolean,
    message: string
}

const EmailForm = () => {
    let [data, setData] = useState<Email>({
        Recipient: "",
        Subject: "",
        Body: ""
    })
    let [error, setError] = useState<IError>({display: false, message: ''})

    function handleSubmit(e: React.SyntheticEvent) {
        e.preventDefault()
        apiCall("POST", data)
            .then(res => res.json())
            .then(response => {
                if(response.Status) {
                    setData({
                        Recipient: "",
                        Subject: "",
                        Body: "",
                    })
                }else{
                    setError({display: true, message: response.Message})
                }})
            .catch(e => console.log(e))
            
    }
  return (
    <div>EmailForm</div>
  )
}

export default EmailForm