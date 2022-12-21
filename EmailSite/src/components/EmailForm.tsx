import { Container, Box, Grid, TextField, FormControl, InputLabel, List, Button } from '@mui/material'
import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { Email } from '../app/email'
import { apiCall } from '../app/lib'
import Error from './Error'


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
                if(response.success) {
                    setData({
                        Recipient: "",
                        Subject: "",
                        Body: "",
                    })
                    console.log(response)
                }else{
                    setError({display: true, message: response.message})
                }})
            .catch(e => console.log(e))
            
    }
    return (
        <Container component='main' maxWidth='xs' sx={{ pt: 10 }}>
            {error.display && <Error error={error} />}
            <Box component="form" autoComplete='off' onSubmit={handleSubmit} sx={{ mt: 3 }}>
                <Grid container spacing={2}>
                    <Grid item xs={12}>
                        <TextField
                            name='Recipient'
                            required
                            fullWidth
                            id='Recipient'
                            // type="email"
                            label='Recipient'
                            value={data.Recipient}
                            onChange={e => setData({ ...data, Recipient: e.target.value })}
                            autoFocus
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <TextField
                            name='Subject'
                            required
                            fullWidth
                            label='Subject'
                            id='Subject'
                            value={data.Subject}
                            onChange={e => setData({ ...data, Subject: e.target.value })}
                        />
                    </Grid>
                    <Grid item xs={12}  sx={{height:100}}>
                        <TextField
                            required
                            fullWidth
                            name="Body"
                            label="Body"
                            id="Body"
                            value={data.Body}
                            onChange={e => setData({ ...data, Body: e.target.value })}
                        />
                    </Grid>
                    </Grid>
                <Button
                    type="submit"
                    fullWidth
                    variant="contained"
                    sx={{ mt: 3, mb: 2 }}
                >
                    Submit
                </Button>
            </Box>
        </Container>
    )
}

export default EmailForm