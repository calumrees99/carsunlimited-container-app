import React from 'react';

import Toolbar from '@mui/material/Toolbar';
import { Typography } from '@mui/material';

import CartButton from '../CartButton/CartButton';

export default function Header() {

  return (
    <React.Fragment>
      <Toolbar sx={{ borderBottom: 1, borderColor: 'divider' }}>
        <Typography variant="h6" color="inherit" noWrap sx={{ flexGrow: 1 }}>
            <img src="/images/logo.png" alt="Cars Unlimited Logo" width="250" />
        </Typography>                  
        <CartButton />
      </Toolbar>     
    </React.Fragment>
  );
}
