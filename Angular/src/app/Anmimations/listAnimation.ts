import {
    state,
    animate,
    transition,
    query,
    group,
    style,
    trigger,
    stagger,
    keyframes
} from "@angular/animations";

export const ListAnimation =
    trigger('ListAnimation', [

        transition('* => *', [ 
           query(':enter',style({opacity: 0}), {optional: true }),

           query(':enter', stagger('100ms',[
            animate('1s ease-in', keyframes([
                style({opacity:0, transform:'translateY(-100px)', offset: 0}),
                style({opacity:0.3, transform:'translateY(50px)', offset: .3}),
                style({opacity:1, transform:'translateY(0)', offset: 1}),
            ]))
           ]), { optional: true }),

           query(':leave', stagger('1000ms',[
            animate('2s ease-in', keyframes([
                style({ 
                    opacity: 1, 
                    transform: 'translateY(0) scale(1)',
                    offset: 0
                }),
                style({
                    opacity: 0.5,
                    transform: 'translateY(50px)  scale(1.2)',
                    offset: .01
                }),
                style({
                    opacity: .3,
                    transform: 'translateY(-50px)  scale(1.5)',
                    offset: 1
                })
            ]))
           ]), { optional: true })

        ])
    ]);