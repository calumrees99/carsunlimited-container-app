import React from "react";
import styles from "./Rating.module.css";
import { Box, Rating as MuiRating } from "@mui/material";

type RatingProps = {
  showLabel?: boolean;
}

function RenderLabel({showLabel = true}: RatingProps){
  if (!showLabel) {
    return null;    
  } else {
    return <Box className={styles.label}><strong>Rating:&nbsp;</strong></Box>
  }
}

const Rating = ({showLabel}: RatingProps) => (
  <div className={styles.Rating} data-testid="Rating">
    <Box
      sx={{
        width: 200,
        display: "flex",
        alignItems: "center",
      }}
    >
      <RenderLabel showLabel={showLabel}/>
      <MuiRating name="product-rating" precision={0.5} value={4.5} readOnly />
      <Box sx={{ ml: 1 }}>(10)</Box>
    </Box>
  </div>
);

export default Rating;
