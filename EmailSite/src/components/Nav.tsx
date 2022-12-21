import { Box, AppBar, Toolbar, Typography, Button} from '@mui/material'

const Nav = () => {
  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static">
        <Toolbar>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            Clarity Ventures Emailer
          </Typography>
        </Toolbar>
      </AppBar>
    </Box>
  )
}

export default Nav