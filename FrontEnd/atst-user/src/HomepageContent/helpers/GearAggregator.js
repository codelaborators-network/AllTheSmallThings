class GearAggregator {
  calculateTotal(events) {
    console.log('gear', events);
    return events.map(item => parseInt(item.Value) === 1000 ? 'Wooden Spear' : 'Wooden Shield');
  }
}

export default new GearAggregator();