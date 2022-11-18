// import {
//   trigger,
//   transition,
//   style,
//   query,
//   group,
//   animateChild,
//   animate,
//   keyframes,
// } from '@angular/animations';

// export const fader =
//   trigger('routeAnimations', [
//     transition('* <=> *', [
//       // Set a default  style for enter and leave
//       query(':enter, :leave', [
//         style({
//           position: 'absolute',
//           left: 0,
//           width: '100%',
//           opacity: 0,
//           transform: 'scale(0) translateY(100%)',
//         }),
//       ]),
//       // Animate the new page in
//       query(':enter', [
//         animate('1000ms ease', style({ opacity: 1, transform: 'scale(1) translateY(0)' })),
//       ])
//     ]),
// ]);

// export const slider =
//   trigger('routeAnimations', [
//     transition('* => isLeft', slideTo('left') ),
//     transition('* => isRight', slideTo('right') ),
//     transition('isRight => *', slideTo('left') ),
//     transition('isLeft => *', slideTo('right') )
//   ]);

// function slideTo(direction:any) {
//   const optional = { optional: true };
//   return [
//     query(':enter, :leave', [
//       style({
//         position: 'absolute',
//         top: 0,
//         [direction]: 0,
//         width: '100%'
//       })
//     ], optional),
//     query(':enter', [
//       style({ [direction]: '-100%'})
//     ]),
//     group([
//       query(':leave', [
//         animate('600ms ease', style({ [direction]: '100%'}))
//       ], optional),
//       query(':enter', [
//         animate('600ms ease', style({ [direction]: '0%'}))
//       ])
//     ]),
//     // Normalize the page style... Might not be necessary

//     // Required only if you have child animations on the page
//     // query(':leave', animateChild()),
//     // query(':enter', animateChild()),
//   ];
// }


// export const stepper =
//   trigger('routeAnimations', [
//     transition('* <=> *', [
//       query(':enter, :leave', [
//         style({
//           position: 'absolute',
//           left: 0,
//           width: '100%',
//         }),
//       ]),
//       group([
//         query(':enter', [
//           animate('2000ms ease', keyframes([
//             style({ transform: 'scale(0) translateX(100%)', offset: 0 }),
//             style({ transform: 'scale(0.5) translateX(25%)', offset: 0.3 }),
//             style({ transform: 'scale(1) translateX(0%)', offset: 1 }),
//           ])),
//         ]),
//         query(':leave', [
//           animate('2000ms ease', keyframes([
//             style({ transform: 'scale(1)', offset: 0 }),
//             style({ transform: 'scale(0.5) translateX(-25%) rotate(0)', offset: 0.35 }),
//             style({ opacity: 0, transform: 'translateX(-50%) rotate(-180deg) scale(6)', offset: 1 }),
//           ])),
//         ])
//       ]),
//     ])

// ]);