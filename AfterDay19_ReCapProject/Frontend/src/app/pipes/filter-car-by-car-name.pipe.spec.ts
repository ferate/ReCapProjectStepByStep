import { FilterCarByCarNamePipe } from './filter-car-by-car-name.pipe';

describe('FilterCarByCarNamePipe', () => {
  it('create an instance', () => {
    const pipe = new FilterCarByCarNamePipe();
    expect(pipe).toBeTruthy();
  });
});
