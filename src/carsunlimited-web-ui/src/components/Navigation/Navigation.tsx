import React from "react";
import styles from "./Navigation.module.css";

import {
  Toolbar,
  Button,
  Input,
  FormControl,
  InputAdornment,
  Stack,
  CssBaseline,
} from "@mui/material";

import "../../helpers/FontAwesome";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

const featureFlagSearch = process.env.REACT_APP_FEATURE_FLAG_SEARCH;
const featureFlagOffers = process.env.REACT_APP_FEATURE_FLAG_OFFERS;

function Search() {
  if (featureFlagSearch === "1") {
    return (
      <FormControl variant="standard">
        <Input
          id="input-with-icon-adornment"
          startAdornment={
            <InputAdornment position="start">
              <FontAwesomeIcon icon={["fas", "search"]} />
            </InputAdornment>
          }
          placeholder="Search"
        />
      </FormControl>
    );
  } 
  
  return null;  
}

function Offers() {
  if (featureFlagOffers === "1") {
    return <Button href="/Offers">Offers</Button>;
  }

  return null;
}

function Navigation() {

  return (
  <div className={styles.Navigation} data-testid="Navigation">
    <CssBaseline />
    <Toolbar sx={{ borderBottom: 1, borderColor: "divider" }}>
    <Stack direction="row" spacing={2} sx={{ flexGrow: 1 }}>
        <Button href="/" startIcon={<FontAwesomeIcon icon={["fas", "home"]} />}>
          Home
        </Button>
        <Button href="/Cars">Cars</Button>
        <Button href="/Parts">Parts</Button>
        <Button href="/Accessories">Accessories</Button>
        <Offers />
      </Stack>      
      <Search />        
    </Toolbar>
  </div>
  );
}

export default Navigation;
