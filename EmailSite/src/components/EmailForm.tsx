import React, { useEffect, useState } from 'react'
import { Email } from '../app/email'
import { apiCall } from '../app/lib'

const EmailForm = () => {
    let [data, setData] = useState<Email>({
        Recipient: "",
        Subject: "",
        Body: ""
    })

    async function handleSubmit(e: React.SyntheticEvent) {
        e.preventDefault()
        apiCall("POST", data)
            .then(response => {
                if(response.ok) {
                    setData({
                        Recipient: "",
                        Subject: "",
                        Body: "",
                    })
                }
            })
    }
  return (
    <div>EmailForm</div>
  )
}

export default EmailForm