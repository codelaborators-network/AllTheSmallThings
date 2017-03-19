const ADD_EVENT = 100;
const REMOVE_EVENT = 200;

class XpAggregator {
  calculateTotal(events) {
    let total = 0;

    events.forEach((ev) => {
      if (ev.AventType === ADD_EVENT) total += ev.XP;
      if (ev.AventType === REMOVE_EVENT) total -= ev.XP;
    });

    return total;
  }
}

export default XpAggregator;