import React from "react";

export interface CartItem {
    id: string;
    count: number;
    price: number;
}

export default interface CartContents {
    items: CartItem[];
    total: number;
}