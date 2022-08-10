import React from "react";
import "react-responsive-carousel/lib/styles/carousel.min.css";
import styles from "./Carousel.module.css";
import { Carousel as Slider } from "react-responsive-carousel";

export default function Carousel() {
  return (
    <Slider
      showArrows={true}
      showThumbs={false}
      showStatus={false}
      interval={6000}
      autoPlay={true}
      infiniteLoop={true}
      dynamicHeight={false}
      className={styles.Carousel}
    >
      <div className={styles.carouselItem}>
        <img
          src="/images/placeholder/1.png"
          alt="BMW i4 M50"
        />
      </div>
      <div className={styles.carouselItem}>
        <img
          src="/images/placeholder/2.png"
          alt="Lambourghini Countach LP800-4 (2022)"
        />
      </div>
      <div className={styles.carouselItem}>
        <img
          src="https://www.thetimes.co.uk/imageserver/image/%2Fmethode%2Fsundaytimes%2Fprod%2Fweb%2Fbin%2F3297ea5c-9d19-11eb-9528-e3733dc789af.jpg?crop=2667%2C1500%2C0%2C0"
          alt="Ferrari Roma"
        />
      </div>
    </Slider>
  );
}
