import { Grid } from "@mui/material";
import React from "react";
import { v4 as uuidv4 } from 'uuid';
import Header from "../components/Header/Header";
import Navigation from "../components/Navigation/Navigation";

import styles from "./MainLayout.module.css";

type Props = {
  children: React.ReactNode;
};

const Layout = ({ children }: Props) => {

  const sessionId = React.useState(
     localStorage.getItem("sessionId") || ''
  );

  if(sessionId[0] === '') {
    const id = uuidv4();
    localStorage.setItem("sessionId", id);
  }



  return (
    <div className={styles.MainLayout}>
      <Header />
      <Grid container spacing={0}>
        <Grid item xs={12}>
          <Navigation />
        </Grid>
      </Grid>
      {children}
    </div>
  );
};

export default Layout;
