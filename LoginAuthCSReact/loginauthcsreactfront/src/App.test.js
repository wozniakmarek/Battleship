import { render, screen } from '@testing-library/react';
import App from './App';

test('renders learn react link', () => {
  render(<App />);
  const linkElement = screen.getByText(/learn react/i);
  expect(linkElement).toBeInTheDocument();
});

test('renders App component correctly', () => {
  const { getByTestId } = render(<App />);
  expect(getByTestId('app-component')).toBeInTheDocument();
});

test('renders welcome text correctly', () => {
  const { getByText } = render(<App />);
  expect(getByText('Welcome To HomePage')).toBeInTheDocument();
});