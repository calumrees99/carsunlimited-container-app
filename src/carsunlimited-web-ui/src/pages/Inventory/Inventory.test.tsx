import React from 'react';
import { render, screen } from '@testing-library/react';
import '@testing-library/jest-dom/extend-expect';
import Inventory from './Inventory';

describe('<Inventory />', () => {
  test('it should mount', () => {
    render(<Inventory />);
    
    const inventory = screen.getByTestId('Inventory');

    expect(inventory).toBeInTheDocument();
  });
});