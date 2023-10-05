using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Behaviors
{
    public class NoScrollBehavior : Behavior<CollectionView>
    {
        protected override void OnAttachedTo(CollectionView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.Scrolled += OnScrolled;
        }

        protected override void OnDetachingFrom(CollectionView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.Scrolled -= OnScrolled;
        }

        private void OnScrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            // Disable scrolling by resetting the vertical offset to 0
            if (sender is CollectionView collectionView)
            {
                collectionView.ScrollTo(0);
            }
        }
    }

}
