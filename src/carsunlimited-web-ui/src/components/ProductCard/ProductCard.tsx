import React from "react";
import styles from './ProductCard.module.css';

import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Typography from "@mui/material/Typography";
//import Rating from "../Rating/Rating";

import { InventoryImage, InventoryItem } from "../../models/InventoryItem.d";

import { Link } from "react-router-dom";

type Props = {
  item: InventoryItem;
}

const getInventoryImage = (images: InventoryImage[]) => {
  return images.find((image: InventoryImage) => image.isPrimary) || images[0] || "https://dummyimage.com/300x200/eee/aaa.png&text=No+image+available";
};

export default function ProductCard({ item }: Props) {

  return (
    <div className={styles.ProductCard} data-testid="ProductCard">
    <Link to={`/Product/${item.manufacturer}/${item.model}`}>
      <Card sx={{ maxWidth: 345 }}>
        <CardMedia
          component="img"
          height="200"
          image={getInventoryImage(item.images).imageUrl}
          alt="{item.manufacturer} {item.model}"
        />
        <CardContent>
          <Typography gutterBottom variant="h6" component="div">
            {item.manufacturer} {item.model}
          </Typography>
          {/* <Typography variant="body2" color="text.secondary">
            <Rating showLabel={false} />
          </Typography> */}
          <Typography variant="button" color="text.secondary" align="right">
            <strong>&pound;{item.price.toLocaleString(navigator.language, { minimumFractionDigits: 2 })}</strong>
          </Typography>
        </CardContent>
      </Card>
    </Link>
    </div>
  );
}
